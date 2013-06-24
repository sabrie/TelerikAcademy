var Wheel = (function() {
    inherit(Wheel, PropulsionUnit);

    function Wheel(radius) {
        PropulsionUnit.call(this);

        this.radius = radius;
    }

    Wheel.prototype.produceAcceleration = function() {
        return 2 * Math.PI * this.radius;
    };

    return Wheel;
}());
