var PropellingNozzle = (function () {
    inherit(PropellingNozzle, PropulsionUnit);

    function PropellingNozzle(power) {
        PropulsionUnit.call(this);

        this.power = power;

        this.afterBurner = false;
    }

    PropellingNozzle.prototype.switchAfterburner = function () {
        this.afterBurner = !this.afterBurner;

        return this;
    };

    PropellingNozzle.prototype.produceAcceleration = function () {
        if (this.afterBurner) {
            return 2 * this.power;
        } else {
            return this.power;
        }
    };

    return PropellingNozzle;
}());
