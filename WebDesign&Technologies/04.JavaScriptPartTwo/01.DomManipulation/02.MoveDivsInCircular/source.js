/*
Write a script that creates 5 div elements and moves them in circular path with interval of 100 milliseconds

*/

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

        currentAngle += 0.05;
        currentAngle %= 2 * Math.PI;

        requestAnimationFrame(animLoop);
    }());

    (function () {
        window.addEventListener('mousemove', function (e) {
            var i;

            var circles = document.querySelectorAll('.circle');

            for (i = 0; i < circles.length; i++) {
                circles[i].style.marginLeft = e.clientX + 'px';
                circles[i].style.marginTop = e.clientY + 'px';
            }
        });
    }());
}());



// More complicated - three levels of rotating divs

/*
var move = (function () {
    var angle = 0;

    return function (circles, radius) {
        var i, currentAngle;

        var stepAngle = 2 * Math.PI / circles.length;

        for (i = 0; i < circles.length; i++) {
            currentAngle = stepAngle * i

            circles[i].style.left = Math.cos(angle + currentAngle) * radius + 'px';
            circles[i].style.top = Math.sin(angle + currentAngle) * radius + 'px';
        }

        angle += 0.005;
    }
}());

(function animLoop() {
    var innerRadius = 100;
    var outerRadius = 150;

    var innerCircles = document.querySelectorAll('.js-circle-inner');
    var outerCircles = document.querySelectorAll('.js-circle-outer');

    move(innerCircles, innerRadius);
    move(outerCircles, outerRadius);

    requestAnimationFrame(animLoop);
}());

// Moves all circles
(function () {
    var allCircles = document.querySelectorAll('.circle');

    window.addEventListener('mousemove', function (e) {
        var i;

        for (i = 0; i < allCircles.length; i++) {
            allCircles[i].style.marginLeft = e.clientX + 'px';
            allCircles[i].style.marginTop = e.clientY + 'px';
        }
    });
}())
*/