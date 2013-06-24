window.requestAnimFrame = (function () {
    return window.requestAnimationFrame ||
            window.webkitRequestAnimationFrame ||
            window.mozRequestAnimationFrame ||
            function (callback) {
                window.setTimeout(callback, 1000 / 60);
            };
})();

var canvas = document.getElementById("canvas");
var ctx = canvas.getContext("2d");

var width = canvas.width = 400;
var height = canvas.height = 300;

var radius = 10;

ctx.fillStyle = "green";
ctx.lineWidth = 5;
ctx.fillRect(0, 0, width, height);
ctx.strokeRect(0, 0, width, height);


function drawCircle(point) {
    ctx.clearRect(0, 0, width, height);
    ctx.beginPath();
    ctx.arc(point.x + radius, point.y + radius, radius, 0, Math.PI * 2, true);
    ctx.fill();
    ctx.closePath();
};

var position = new Point(0, 0);
var direction = new Point(3, 3); // change the speed here

function moveCircle() {
    position = Point.add(position, direction);
    drawCircle(position);

    if (!(0 <= position.x && position.x + 2 * radius < width)) {
        direction.x *= -1;
    }

    if (!(0 <= position.y && position.y + 2 * radius < height)) {
        direction.y *= -1;
    }

    requestAnimationFrame(moveCircle);
};

moveCircle();
