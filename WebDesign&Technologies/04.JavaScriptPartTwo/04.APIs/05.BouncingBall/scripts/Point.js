var Point = (function () {
    var Point = function (x, y) {
        this.x = x;
        this.y = y;
    };

    Point.add = function (point1, point2) {
        return new Point(
            point1.x + point2.x,
            point1.y + point2.y
        );
    };

    Point.prototype.multiply = function (number) {
        return new Point(
            this.x * number,
            this.y * number
        );
    }

    Point.prototype.toString = function () {
        var string = "x: " + this.x + ", y: " + this.y;

        return string;
    }

    return Point;
}());

//console.log(Point.add(new Point(10, 10), new Point(-20, -20)));
//console.log(new Point(10, 10).multiply(3).toString());
