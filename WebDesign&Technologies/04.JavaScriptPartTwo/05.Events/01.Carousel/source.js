var images = [
    "images/Agassi_Federer.jpg",
    "images/Amelie.jpg",
    "images/Nadal.jpg",
    "images/Sharapova.jpg"
];

var image = document.getElementById("images");
var currentImageNumber = 0;

function nextImage() {

    if (currentImageNumber === images.length - 1) {
        currentImageNumber = 0;
    } else {
        currentImageNumber++;
    }

    image.src = images[currentImageNumber];    
}

function previousImage() {

    if (currentImageNumber === 0) {
        currentImageNumber = images.length - 1;
    } else {
        currentImageNumber--;
    }
    image.src = images[currentImageNumber];    
}

var previousButton = document.getElementById('previous');

previousButton.addEventListener('click', function (e) {
    // IE keeps the event object in window.event
    e = e || window.event;

    e.preventDefault()
    previousImage();
}, false);

var nextButton = document.getElementById('next');

nextButton.addEventListener('click', function (e) {
    // IE keeps the event object in window.event
    e = e || window.event;

    e.preventDefault()
    nextImage();
}, false);